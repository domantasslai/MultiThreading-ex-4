using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bandymas
{
	class Block<T>
	{
		public int index;
		public string previousHash, hash;

		public DateTime date;
		public string Pavarde;

		public Block(int i, string prevHash, string hash, DateTime date,
			string Pavarde)
		{
			index = i;
			previousHash = prevHash;
			this.hash = hash;

			this.date = date;
			this.Pavarde = Pavarde;
		}
	}
}
