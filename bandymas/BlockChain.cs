using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace bandymas
{
	class BlockChain
	{
		public ArrayList Chain = new ArrayList();
		int current;
		public string firstHash;
		string data;

		public BlockChain(string prevHash, DateTime date,
			string Pavarde)
		{
			string data = Pavarde;
			current = 0;

			string hash = GetHash(current, prevHash, data, date);
			firstHash = hash;
			Block<string> b = new Block<string>(current, prevHash, hash, date, Pavarde);
			Chain.Add(b);
			current++;

		}

		public Block<string> AddBlock(string prevHash, DateTime date, string Pavarde)
		{
			data = Pavarde;
			string hash = GetHash(current, prevHash, data, date);
			Block<string> b = new Block<string>(current, prevHash, hash, date, Pavarde);

			object o = Chain[current - 1];

			if(validate((Block<string>)o, b))
			{
				Chain.Add(b);
				current++;
			}

			else
			{
				throw new Exception("Chain not valid");
			}

			return b;
		}

		private string GetHash(int i, string prevHash, string data, DateTime date)
		{
			return getSHA(i.ToString() + prevHash + data + date.ToString());
		}

		private string getSHA(string str)
		{
			SHA256Managed crypt = new SHA256Managed();
			StringBuilder hash = new StringBuilder();
			byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));
			foreach (byte theByte in crypto)
			{
				hash.Append(theByte.ToString("x2"));
			}
			return hash.ToString();
		}

		bool validate(Block<string> prevB, Block<string> newB)
		{
			bool valid = true;

			string newHash = getSHA(newB.index.ToString() + newB.previousHash + data + newB.date.ToString());

			if (prevB.index + 1 != newB.index)
			{
				valid = false;
				throw new Exception("index");
			}

			if (prevB.hash != newB.previousHash)
			{
				valid = false;
				throw new Exception("index");
			}

			if (newHash != newB.hash)
			{
				valid = false;
				throw new Exception("index");
			}

			/*if (prevB.index + 1 != newB.index || prevB.hash != newB.previousHash || newHash != newB.hash)
            {
                valid = false;
            }*/

			return valid;
		}
	}
}
