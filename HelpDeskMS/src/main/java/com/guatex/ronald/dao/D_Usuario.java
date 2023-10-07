package com.guatex.ronald.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.LinkedList;
import java.util.List;
import com.guatex.ronald.models.E_Usuario;
import com.guatex.ronald.models.pkgUsuario;
import com.guatex.ronald.utils.utils;

public class D_Usuario {
	private String dbUrl = "jdbc:oracle:thin:@localhost:1521:xe";
	private String username = "HELPDATA";
	private String password = "ron2";

	utils util = new utils();

	public pkgUsuario getUser(String user, String pass) {
		E_Usuario datos = new E_Usuario();
//		String sql = "SELECT USUARIO, PASSWORD FROM USUARIO WHERE USUARIO = ? AND PASSWORD = ?";
		String sql = "SELECT " + "  U.ID_USUARIO, " + "  U.USUARIO, " + "  E.ID_EMPLEADO, " + "  E.ID_DEPARTAMENTO, "
				+ "  D.NOMBRE_DEPARTAMENTO, " + "  E.ID_ROL, " + "  R.NOMBRE_ROL, " + "  E.NOMBRE, " + "  E.APELLIDO, "
				+ "  E.TELEFONO, " + "  E.CORREO " + "FROM " + "  USUARIO U "
				+ "  LEFT JOIN EMPLEADO E ON U.ID_USUARIO = E.ID_USUARIO "
				+ "  LEFT JOIN DEPARTAMENTO D ON E.ID_DEPARTAMENTO = D.ID_DEPARTAMENTO"
				+ "  LEFT JOIN ROL R ON E.ID_ROL = R.ID_ROL" + "  WHERE U.USUARIO = ? AND U.PASSWORD = ? ";

		try (Connection con = DriverManager.getConnection(dbUrl, username, password);
				PreparedStatement ps = con.prepareStatement(sql)) {
			if (!util.quitaNulo(user).isEmpty() || !util.quitaNulo(pass).isEmpty()) {
				System.out.println("usuario que llega es: " + user + " pass: " + pass);
				ps.setString(1, user);
				ps.setString(2, pass);
				try (ResultSet rs = ps.executeQuery()) {
					if (rs.next()) {
						datos.setIdUsuario(util.quitaNulo(rs.getString("ID_USUARIO")));
						datos.setUsuario(util.quitaNulo(rs.getString("USUARIO")));
						datos.setIdEmpleado(util.quitaNulo(rs.getString("ID_EMPLEADO")));
						datos.setIdDepartamento(util.quitaNulo(rs.getString("ID_DEPARTAMENTO")));
						datos.setDepartamento(util.quitaNulo(rs.getString("NOMBRE_DEPARTAMENTO")));
						datos.setIdRol(util.quitaNulo(rs.getString("ID_ROL")));
						datos.setRol(util.quitaNulo(rs.getString("NOMBRE_ROL")));
						datos.setNombreEmpleado(util.quitaNulo(rs.getString("NOMBRE")));
						datos.setApellidoEmpleado(util.quitaNulo(rs.getString("APELLIDO")));
						datos.setTelefonoEmpleado(util.quitaNulo(rs.getString("TELEFONO")));
						datos.setCorreoEmpleado(util.quitaNulo(rs.getString("CORREO")));

						return new pkgUsuario("200", datos);
					} else {
						return new pkgUsuario("401", datos);
					}
				}
			} else {
				return new pkgUsuario("400", datos);
			}
		} catch (SQLException e) {
			System.out.println("Opps, error: [" + e.getMessage() + "]");
		}
		return new pkgUsuario("500", datos);
	}

	public pkgUsuario getUserList() {
		String sql = "SELECT *FROM USUARIO";
		List<E_Usuario> users = new LinkedList<>();
		try (Connection con = DriverManager.getConnection(dbUrl, username, password);
				PreparedStatement ps = con.prepareStatement(sql)) {
			try (ResultSet rs = ps.executeQuery()) {
				while (rs.next()) {
					E_Usuario u = new E_Usuario();
					u.setIdUsuario(util.quitaNulo(rs.getString(1)));
					u.setUsuario(util.quitaNulo(rs.getString(2)));
					u.setIdEmpleado(util.quitaNulo(rs.getString(3)));
					u.setIdDepartamento(util.quitaNulo(rs.getString(4)));
					u.setDepartamento(util.quitaNulo(rs.getString(5)));
					u.setIdRol(util.quitaNulo(rs.getString(6)));
					u.setRol(util.quitaNulo(rs.getString(7)));
					u.setNombreEmpleado(util.quitaNulo(rs.getString(8)));
					u.setApellidoEmpleado(util.quitaNulo(rs.getString(9)));
					u.setTelefonoEmpleado(util.quitaNulo(rs.getString(10)));
					u.setCorreoEmpleado(util.quitaNulo(rs.getString(11)));
					users.add(u);
				}

				if (users.size() > 0) {
					return new pkgUsuario("200", users);
				}else {
					return new pkgUsuario("201", users);
				}

			}
		} catch (SQLException e) {
			System.out.println("Opps, error: " + e.getErrorCode());
		}
		return new pkgUsuario("500", users);
	}

	public boolean createUser(E_Usuario datos) {
		boolean respuesta = false;
		String sql = "INSERT INTO USUARIO (USUARIO , PASSWORD) VALUES (?, ?)";

		try (Connection con = DriverManager.getConnection(dbUrl, username, password);
				PreparedStatement ps = con.prepareStatement(sql)) {
//			ps.setString(1, util.quitaNulo(datos.));
//			ps.setString(2, util.quitaNulo(datos.getPassword()));
			if (ps.executeUpdate() > 0) {
				respuesta = true;
			}
		} catch (SQLException e) {
			System.out.println("Opps, error: ");
			e.printStackTrace();
		}
		return respuesta;
	}
}
