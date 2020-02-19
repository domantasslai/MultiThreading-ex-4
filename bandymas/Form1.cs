using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bandymas
{
	public partial class Form1 : Form
	{
		static BlockChain chain;
		static string currHash = string.Empty;
		int counter1 = 0;
		int counter2 = 0;
		string simonyte;
		string nauseda;

		public Form1()
		{
			InitializeComponent();
			Pasirinkimas.Items.Add("Nausėda");
			Pasirinkimas.Items.Add("Šimonytė");
		}

		public void local(string Pavarde)
		{
			chain = new BlockChain("0", DateTime.Now, Pavarde);
			currHash = chain.firstHash;
		}

		private void balsuotiBtn_Click(object sender, EventArgs e)
		{
			simonyte = simonytesbalai.Text;
			nauseda = nausedosbalai.Text;
			int Svalue = Int32.Parse(simonyte);
			int Nvalue = Int32.Parse(nauseda);

			if(Pasirinkimas.Text =="Nausėda")
			{
				counter1++;
				nausedosbalai.Text = counter1.ToString();
				add(Pasirinkimas.Text);

				if(Nvalue >= Svalue)
				{
					nausedalabel.Location = new Point(13, 53);
					simonytelabel.Location = new Point(13, 98);
					simonytesbalai.Location = new Point(116, 98);
					nausedosbalai.Location = new Point(116, 53);
				}
			}
			else
			{
				counter2++;
				simonytesbalai.Text = counter2.ToString();
				add(Pasirinkimas.Text);
				if (Svalue >= Nvalue)
				{
					nausedalabel.Location = new Point(13, 98);
					simonytelabel.Location = new Point(13, 53);
					simonytesbalai.Location = new Point(116, 53);
					nausedosbalai.Location = new Point(116, 98);
				}
			}

			if(Pasirinkimas.Text!= "Nausėda" && Pasirinkimas.Text!= "Šimonytė")
			{
				MessageBox.Show("Blogai įvestas kandidatas");
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			local(Pasirinkimas.Text);
		}

		static void list()
		{
			foreach(Block<string> c in chain.Chain)
			{
				Block<string> ch = c;
				Console.WriteLine($"Block { ch.index }:  {ch.hash}: {ch.previousHash}:");
			}
			Console.WriteLine("");
		}


		static void add(string Pavarde)
		{
			Block<string> c = chain.AddBlock(currHash, DateTime.Now, Pavarde);

			Console.WriteLine($"Block( { c.date.ToString() }, { c.hash })\n");

			currHash = c.hash;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			list();
			//PardoytiBlockchain();
		}

		private void label9_Click(object sender, EventArgs e)
		{

		}
	}
}
