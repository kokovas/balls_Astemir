using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Data.Common;
using System.Data.OleDb;
using Mono.Data.Sqlite;
using System.IO;

public class DataBase {
	private static DataBase _instance = null;							// 
	public static string _dbPath;										// путь к базе данных
	SqliteConnection _connection = null;								// 

	// конструктор класса
	private DataBase()
	{
		initializePath();												// инициализируем путь
		openConnection();												// открываем соединение
	}

	// метод открывающий базу данных
	public void openConnection() {
		if (_connection == null) {									
			// ...
			_connection =  new SqliteConnection(string.Format("Data Source={0};", _dbPath));
			_connection.Open();											//
		}
	}

	// метод закрывающий базу данных
	public void closeConnection()
	{
		// соединение открыто, то
		if (_connection != null) {
			_connection.Close();										// закрываем сединение
			_connection = null;											// обнуляем переменную
		}
	}

	// ...
	public static DataBase getInstance()
	{
		if (_instance == null) {
			_instance = new DataBase();									//
		}

		return _instance;												//
	}

	// создание базы данных
	void dbCreate() {
		string _dbName; 												// имя создаваемой базы данных
		
		if (Application.platform == RuntimePlatform.WindowsEditor) { 
			_dbName = Application.dataPath + "/db.bytes"; 				// задаём имя базе данных
			SqliteConnection.CreateFile(_dbName); 						// создаём базу данных
		} else if (Application.platform == RuntimePlatform.Android) {
			// ...
		}
	}
	
	// определение пути к БД
	void initializePath() {
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor) {		// для Windows и MacOS
			_dbPath = Application.dataPath + "/db.bytes";
		} else if (Application.platform == RuntimePlatform.Android) {															// для Android
			_dbPath = "jar:file://" + Application.dataPath + "!/assets/db.bytes";
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) { 														// для IOS
			_dbPath = Application.dataPath + "/Raw/db.bytes";
		}
	}

	// выполнение sql - запросов
	public int query(string sql)
	{
		if (_connection == null) {
			openConnection();											//
		}

		SqliteCommand command = new SqliteCommand(sql, _connection);	//
		int affectedRows = 0;

		try {
			affectedRows = command.ExecuteNonQuery();					//
		} catch (Exception e) {
			Debug.LogError(e.Message);									//
		}

		return affectedRows;											//
	}

	public List<Hashtable> fetch(string sql)
	{
		int i;															//
		List<Hashtable> list    = new List<Hashtable>();				//
		SqliteDataReader reader = select(sql);							//

		if (reader == null) {
			Debug.LogError("FETCH ERROR: " + sql);						//
			return list;												//
		}

		while (reader.Read()) {
			Hashtable row = new Hashtable();							//

			for (i = 0; i < reader.FieldCount; i++) {
				row.Add(reader.GetName(i), reader[reader.GetName(i)]);	//
			}

			list.Add(row);												//
		}

		reader.Close();													//

		return list;													//
	}

	public SqliteDataReader select(string sql) {
		SqliteCommand command = new SqliteCommand(sql, _connection);	//
		return command.ExecuteReader();									//
	}
}