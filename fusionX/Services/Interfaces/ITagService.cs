﻿using hackweek_backend.Dtos;
using hackweek_backend.Models;

namespace hackweek_backend.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag?> GetTagByIdAsync(uint id);
        Task<Tag> CreateTagAsync(TagDtoCreate tagDto);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(uint id);
    }
}