using System.Collections.Generic;
using System.Threading.Tasks;
using FirstForms.Models;
using SQLite;


namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
            _database.CreateTableAsync<Account>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }



        public Task<List<Account>> GetAccountsAsync()
        {
            return _database.Table<Account>().ToListAsync();
        }

        public Task<Account> GetAccountsAsync(int id)
        {
            return _database.Table<Account>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAccountsAsync(Account account)
        {
            if (account.ID != 0)
            {
                return _database.UpdateAsync(account);
            }
            else
            {
                return _database.InsertAsync(account);
            }
        }

        public Task<int> DeleteNoteAsync(Account login)
        {
            return _database.DeleteAsync(login);
        }


    }
}