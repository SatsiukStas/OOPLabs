using System;
using oop2.Entities;
using SerializerLib;
namespace oop2.Services
{
	public class Collection
    {
        //private List<User> collection;
        //private string path = "/Users/stanislav/Projects/oop2/oop2/bin/Debug/net7.0/aa.json";
        //public Collection()
        //{
        //    collection = new List<User>();
        //}
        //public async Task AddAsync(User entity)
        //{
        //    await Task.Run(() =>
        //    {
        //        collection.Add(entity);
        //    });
        //}



        //public async Task DeleteByIdAsync(Guid id)
        //{
        //    await Task.Run(() =>
        //    {
        //        var item = FindByIdAsync(id).Result;
        //        if (item != null)
        //        {
        //            collection.Remove(item);
        //        }
        //    });
        //}

        //public async Task<bool> ExistsById(Guid id)
        //{
        //    return await Task.Run(() =>
        //    {
        //        var item = FindByIdAsync(id).Result;
        //        if (!item != null)
        //        {
        //            return true;
        //        }

        //        return false;
        //    });
        //}

        //public async Task<T?> FindByIdAsync(Guid id)
        //{
        //    return await Task.Run(() =>
        //    {
        //        return collection.Where(x => x.Id == id).FirstOrDefault();
        //    });
        //}

        //public async Task<IEnumerable<User>> GetAllAsync()
        //{
        //    return await Task.Run(() => collection);
        //}

        //public async Task UpdateAsync(T entity)
        //{
        //    await DeleteByIdAsync(entity.Id);
        //    await AddAsync(entity);
        //}

        //public async Task Load()
        //{
        //    await Task.Run(() =>
        //    {
        //        var deserialized = Serializer.Serializer.DeSerializeJSONAsync<List<User>>(path).Result;
        //        if (deserialized != null)
        //        {
        //            collection.Clear();
        //            collection.AddRange(deserialized);
        //        }
        //    });
        //}

        //public void Save()
        //{
        //    _ = Serializer.Serializer.SerializeJSONAsync<List<User>>(collection, path);
        //    Console.WriteLine("save");
        //}
    }
}

