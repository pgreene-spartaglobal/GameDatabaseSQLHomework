﻿using System;
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
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CSharpGame;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            //Create.AddGame(conn, "Pacman", "Maze", "Arcade", "Very Positive");
            //Read.ReadGames(conn);
            //Update.UpdateGame(conn, "Review", "Mostly Positive", 1);
            //Read.ReadGames(conn);
            //Delete.DeleteGame(conn, 1);
            Read.ReadGames(conn);
        }
    }
    public class Game
    {
        string name = "";
        string genre = "";
        string type = "";
        string review = "";

        public Game(string name, string genre, string type, string review)
        {
            Name = name;
            Genre = genre;
            Type = type;
            Review = review;
        }

        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Type { get => type; set => type = value; }
        public string Review { get => review; set => review = value; }
    }

    class Create
    {
        public static void AddGame(SqlConnection conn, string name, string genre, string type, string review)
        {
            Game game = new Game(name, genre, type, review);

            string insertString = String.Format("INSERT INTO Games (Name, Genre, Type, Review) " +
                                                "VALUES ('{0}', '{1}', '{2}', '{3}')", 
                                                game.Name, game.Genre, game.Type, game.Review);

            try
            {
                conn.Open();
                SqlCommand insertCommand = new SqlCommand(insertString, conn);
                insertCommand.ExecuteReader();
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

    class Read
    {
        public static void ReadGames(SqlConnection conn)
        {
            string selectString = "SELECT * FROM Games";

            try
            {
                conn.Open();
                SqlCommand selectCommand = new SqlCommand(selectString, conn);
                SqlDataReader dataReader = selectCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Console.WriteLine(dataReader.GetValue(i));
                    }
                    Console.WriteLine();
                }
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

    class Update
    {
        public static void UpdateGame(SqlConnection conn, string columnName, string value, int id)
        {
            string updateString = String.Format("UPDATE Games " +
                                  "SET {0} = '{1}' " +
                                  "WHERE ID = '{2}' ", columnName, value, id);

            try
            {
                conn.Open();
                SqlCommand updateCommand = new SqlCommand(updateString, conn);
                updateCommand.ExecuteReader();
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

    class Delete
    {
        public static void DeleteGame(SqlConnection conn, int id)
        {
            string deleteString = String.Format("DELETE FROM Games " +
                      "WHERE ID = '{0}' ", id);

            try
            {
                conn.Open();
                SqlCommand deleteCommand = new SqlCommand(deleteString, conn);
                deleteCommand.ExecuteReader();
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
}