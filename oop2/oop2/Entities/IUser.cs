using System;
using oop2.Services;

namespace oop2.Entities
{
	public interface IUser
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}

