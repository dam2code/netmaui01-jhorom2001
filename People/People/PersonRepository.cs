using People.Models;
using SQLite;

namespace People;

public class PersonRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    private SQLiteAsyncConnection conn;

    private async Task Init()
    {
        if (conn != null) return;

        conn = new SQLiteAsyncConnection(_dbPath);

        await conn.CreateTableAsync<Person>();
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;                        
    }

    //METODO PARA ANNADIR UN NUEVO DATO EN LA TABLA PERSON
    public async Task AddNewPerson(string name)
    {            
        int result = 0;
        try
        {
            Init();
            
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valida el nombre");

            result = await conn.InsertAsync(new Person { nombre = name });
            
            StatusMessage = string.Format("{0} dato(s) annadidos (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Fallo al annadir {0}. Error: {1}", name, ex.Message);
        }

    }

    //OBTENER DATOS DE LA BBDD
    public async Task<List<Person>> GetAllPeople()
    {
        try
        {
            await Init();

            return await conn.Table<Person>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Fallo al recibir data. {0}", ex.Message);
        }

        return new List<Person>();
    }
}
