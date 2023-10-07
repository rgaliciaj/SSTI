package com.guatex.ronald.utils;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Conexion {
	private String dbUrl = "jdbc:oracle:thin:@dbserver:1521:xe";
	private String username = "HELPDATA";
	private String password = "ron1";
	
	
	public Connection getConexion () {
		Connection con = null;
		try {
			con = DriverManager.getConnection(dbUrl, username, password);
			System.out.println("Connected to Oracle database server");
		} catch (SQLException e) {
			System.out.println("Opps, error: ");
			e.printStackTrace();
		}
		return con;
	}
}
