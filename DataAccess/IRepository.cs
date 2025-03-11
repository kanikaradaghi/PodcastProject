using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Insert(T theObject);
        void Update(int index, T theObject);
        void Delete(int index);
        void SaveChanges();
        void UpdateName(string name, string? kategori, string? newName);
        void Reset();
        void UpdatePodcastsCategory(string oldCategory, string newCategory);

        void TabortKategoriIPodcast(string gamlaVärdet);
    }
}
