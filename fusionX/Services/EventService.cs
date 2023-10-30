using EvenTech.Data;
using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;
using EvenTech.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EvenTech.Services
{
    public class EventService : IEventService
    {
        private readonly DataContext _context;

        public EventService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<EventDto?> GetEventByIdAsync(uint id)
        {
            var modelEvent = await _context.Events.FindAsync(id);
            if (modelEvent is null)
            {
                return null;
            }
            return new EventDto(modelEvent);
        }

        public async Task<Event> CreateEventAsync(EventDtoCreate eventDtoCreateItem)
        {
            var eventModel = ConvertToModel.ToModel(eventDtoCreateItem);
            _context.Events.Add(eventModel);
            await _context.SaveChangesAsync();
            return eventModel;
        }

        public async Task UpdateEventAsync(uint id, EventDtoUpdate eventDtoUpdateItem)
        {
            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
            {
                throw new InvalidOperationException($"Event with ID {id} not found.");
            }
            ConvertToModel.ToModel(existingEvent, eventDtoUpdateItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(uint id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<uint?> GetUserIdByEvent(uint id)
        {
            var model = await _context.Events.FindAsync(id);

            return model?.UserId;
        }

        private static Dictionary<string, object> SumValuesByKey(JToken node)
        {
            var sumByKey = new Dictionary<string, object>();

            SumValuesByKeyRecursive(node, sumByKey);

            return sumByKey;
        }

        private static void SumValuesByKeyRecursive(JToken node, Dictionary<string, object> sumByKey)
        {
            if (node.Type == JTokenType.Object)
            {
                // Object
                foreach (var property in node.Children<JProperty>())
                {
                    if (property.Value is not null)
                    {
                        // Recursive
                        SumValuesByKeyRecursive(property.Value, sumByKey);

                        if (property.Value.Type == JTokenType.Float || property.Value.Type == JTokenType.Integer)
                        {
                            // Numeric
                            var numValue = (double)property.Value;
                            if ((sumByKey.ContainsKey(property.Name)) && (sumByKey[property.Name] is double))
                                sumByKey[property.Name] = (double)sumByKey[property.Name] + numValue;
                            else
                                sumByKey.Add(property.Name, numValue);
                        }
                        else if (property.Value.Type == JTokenType.String)
                        {
                            // Text
                            var textValue = (string?)property.Value ?? string.Empty;
                            if ((sumByKey.ContainsKey(property.Name)) && sumByKey[property.Name] is List<string>)
                                ((List<string>)sumByKey[property.Name]).Add(textValue);
                            else
                                sumByKey.Add(property.Name, new List<string> { textValue });
                        }
                    }
                }
            }
            else if (node.Type == JTokenType.Array)
            {
                // Array
                foreach (var item in node.Children())
                {
                    SumValuesByKeyRecursive(item, sumByKey);
                }
            }
        }

        public async Task<OverviewDto?> GetEventOverview(uint id)
        {
            var notifications = await _context.Notifications
                .Where(n => (n.EventId == id) && (NotificationConstraints.OverviewTypeIds.Contains(n.Type)))
                .Include(n => n.Feedbacks)
                .ToListAsync();

            var overviewItems = new List<OverviewItemDto>();
            // Loop notifications
            foreach (var notification in notifications)
            {
                var jsonFeedbacks = new JArray() { notification.Feedbacks?.Select(f => JsonConvert.DeserializeObject<JToken>(f.Response)).ToList() };
                var results = SumValuesByKey(jsonFeedbacks);
                var jsonResponse = JsonConvert.SerializeObject(results);

                var type = NotificationConstraints.Types.FirstOrDefault(nt => nt.Id == notification.Type);
                overviewItems.Add(new OverviewItemDto
                {
                    Id = notification.Id,
                    Title = notification.Title,
                    Count = (notification.Feedbacks is null) ? 0 : notification.Feedbacks.Count,
                    Type = (type is null) ? null : new NotificationTypeDto(type),
                    Response = jsonResponse.ToString(),
                });
            }

            return new OverviewDto
            {
                EventId = id,
                Items = overviewItems,
            };
        }
    }
}
