import pyodbc

# Configuração dos parâmetros de conexão
server = 'fusionxdb.cmw2whm4hmzl.us-east-1.rds.amazonaws.com'
database = 'fusionxdb'
username = 'fusion_admin'
password = '3K$w2Z9jXV6F'
port = 1433

try:
    # Realiza a conexão com o banco de dados
    connection_string = f"DRIVER=ODBC Driver 17 for SQL Server;SERVER={server},{port};DATABASE={database};UID={username};PWD={password}"
    conn = pyodbc.connect(connection_string)
    
    # Verifica se a conexão foi bem-sucedida
    if conn:
        print("Conexão bem-sucedida ao banco de dados SQL Server.")
        conn.close()
    else:
        print("Falha na conexão ao banco de dados.")
except Exception as e:
    print(f"Erro durante a conexão ao banco de dados: {str(e)}")