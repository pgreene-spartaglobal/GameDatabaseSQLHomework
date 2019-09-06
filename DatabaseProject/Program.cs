using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Game game1 = new Game();
            game1.Name = "Tetris";
            game1.Genre = "Arcade";
            game1.Type = "Puzzle";
            game1.Review = "Overwhelmingly Positive";

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            string insertString = String.Format("INSERT INTO Games (Name, Genre, Type, Review) VALUES ('{0}', '{1}', '{2}', '{3}')", game1.Name, game1.Genre, game1.Type, game1.Review);

            try
            {                
                conn.Open();
                //SqlCommand insertCommand = new SqlCommand(insertString, conn);
                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Games", conn);
                Game game2 = new Game();
                
                //insertCommand.ExecuteReader();
                //selectCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Something happened to the server " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
             
        }
    }
    public class Game
    {
        string name = "";
        string genre = "";
        string type = "";
        string review = "";

        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Type { get => type; set => type = value; }
        public string Review { get => review; set => review = value; }
    }

    class Create
    {
        public void CreateGame()
        {
            Game game1 = new Game();
            game1.Name = "Tetris";
            game1.Genre = "Arcade";
            game1.Type = "Puzzle";
            game1.Review = "Overwhelmingly Positive";
        }



    }

    class Read
    {

    }

    class Update
    {

    }

    class Delete
    {

    }
}


//using (conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
//{
//    conn.Open();
//    Console.WriteLine(conn.State);
//    SqlCommand selectCommand = new SqlCommand("SELECT * FROM Games", conn);
//    selectCommand.ExecuteReader();
//    //SqlCommand insertCommand = new SqlCommand("INSERT INTO Games (Name, Genre, Type, Review) VALUES (Tetris, Arcade, Puzzle, Overwhelmingly Positive)", conn);
//}