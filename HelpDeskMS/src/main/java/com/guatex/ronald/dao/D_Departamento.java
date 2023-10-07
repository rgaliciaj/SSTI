package com.guatex.ronald.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.LinkedList;
import java.util.List;

import com.guatex.ronald.models.E_Departamento;

public class D_Departamento {
	private String dbUrl = "jdbc:oracle:thin:@localhost:1521:xe";
	private String username = "HELPDATA";
	private String password = "ron2";

	private List<E_Departamento> getDepto() {
		List<E_Departamento> deptoList = new LinkedList<>();
		String sql = "SELECT *FROM DEPARTAMENTO";

		try (Connection con = DriverManager.getConnection(dbUrl, username, password);
				PreparedStatement ps = con.prepareStatement(sql)) {
			try (ResultSet rs = ps.executeQuery()) {
				while (rs.next()) {
					deptoList.add(new E_Departamento(quitaNulo(rs.getString(1)), quitaNulo(rs.getString(2)),
							quitaNulo(rs.getString(3))));
				}
			}
		} catch (SQLException e) {
			System.out.println("Opps, error: ");
			e.printStackTrace();
		}

		return deptoList;
	}
	
	public boolean insertarDepto(E_Departamento datos) {
		boolean respuesta = false;
		String sql = "INSERT INTO DEPARTAMENTO (NOMBRE_DEPARTAMENTO, ID_DEPARTAMENTO_PADRE) "
				+ "VALUES (?, ?)";
		
		try (Connection con = DriverManager.getConnection(dbUrl, username, password);
				PreparedStatement ps = con.prepareStatement(sql)) {
				con.setAutoCommit(false);
				ps.setString(1, quitaNulo(datos.getNombreDepartamento()));
				ps.setString(1, quitaNulo(datos.getIdDeptoPadre()));
				if(ps.executeUpdate()>0) {
					con.setAutoCommit(true);
					respuesta = true;
				}else {
					con.rollback();
					respuesta = false;
				}
			} catch (SQLException e) {
				System.out.println("Upps, error: ");
				e.printStackTrace();
			};
		
		return respuesta;
	}
	
	public List<E_Departamento> listDepto(){
		return getDepto();
	}

	private String quitaNulo(String var) {
		String respuesta = var == null || var.isEmpty() ? var = "" : var.trim();
		return respuesta;
	}
}
