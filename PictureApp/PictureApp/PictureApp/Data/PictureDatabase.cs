using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PictureApp.Models;
using SQLite;

namespace PictureApp.Data
{
     public class PictureDatabase
    {

        readonly SQLiteAsyncConnection _database;

        public PictureDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Picture>().Wait();
            _database.CreateTableAsync<Account>().Wait();
            _database.CreateTableAsync<Comment>().Wait();
            _database.CreateTableAsync<Likes>().Wait();
        }

        public ObservableCollection<Picture> GetPicturesAsync()
        {
            var list= _database.Table<Picture>().ToListAsync();
            ObservableCollection<Picture> pictures = new ObservableCollection<Picture>();
            foreach (var item in list.Result)
                pictures.Add(item);
            return pictures;
        }

        public Task<Picture> GetPictureAsync(int id)
        {
            return _database.Table<Picture>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePictureAsync(Picture picture)
        {
            if (picture.Id != 0)
            {
                return _database.UpdateAsync(picture);
            }
            else
            {
                return _database.InsertAsync(picture);
            }
        }

        public Task<int> DeletePictureAsync(Picture picture)
        {
            return _database.DeleteAsync(picture);
        }


        public Task<List<Account>> GetAccountsAsync()
        {
            return _database.Table<Account>().ToListAsync();
        }

        public Task<Account> GetAccountAsync(int id)
        {
            return _database.Table<Account>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAccountsAsync(Account account)
        {
            if (account.Id != 0)
            {
                return _database.UpdateAsync(account);
            }
            else
            {
                return _database.InsertAsync(account);
            }
        }
        public Task<int> DeleteAccountAsync(Account login)
        {
            return _database.DeleteAsync(login);
        }



        public Task<List<Comment>> GetCommentsAsync()
        {
            return _database.Table<Comment>().ToListAsync();
        }

        public Task<Comment> GetCommentAsync(int id)
        {
            return _database.Table<Comment>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCommentsAsync(Comment comment)
        {
            if (comment.Id != 0)
            {
                return _database.UpdateAsync(comment);
            }
            else
            {
                return _database.InsertAsync(comment);
            }
        }

        public Task<int> DeleteCommentAsync(Comment comment)
        {
            return _database.DeleteAsync(comment);
        }


        public Task<List<Likes>> GetLikesAsync()
        {
            return _database.Table<Likes>().ToListAsync();
        }

        public Task<Likes> GetLikeAsync(int id)
        {
            return _database.Table<Likes>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveLikesAsync(Likes comment)
        {
            if (comment.Id != 0)
            {
                return _database.UpdateAsync(comment);
            }
            else
            {
                return _database.InsertAsync(comment);
            }
        }

        public Task<int> DeleteLikeAsync(Likes comment)
        {
            return _database.DeleteAsync(comment);
        }
    }
}
