package com.guatex.ronald.models;

public class E_Departamento {
	String idDepartamento = "";
	String nombreDepartamento = "";
	String idDeptoPadre = "";
	public String getIdDepartamento() {
		return idDepartamento;
	}
	public void setIdDepartamento(String idDepartamento) {
		this.idDepartamento = idDepartamento;
	}
	public String getNombreDepartamento() {
		return nombreDepartamento;
	}
	public void setNombreDepartamento(String nombreDepartamento) {
		this.nombreDepartamento = nombreDepartamento;
	}
	public String getIdDeptoPadre() {
		return idDeptoPadre;
	}
	public void setIdDeptoPadre(String idDeptoPadre) {
		this.idDeptoPadre = idDeptoPadre;
	}
	public E_Departamento(String idDepartamento, String nombreDepartamento, String idDeptoPadre) {
		super();
		this.idDepartamento = idDepartamento;
		this.nombreDepartamento = nombreDepartamento;
		this.idDeptoPadre = idDeptoPadre;
	}
	public E_Departamento() {}
	
	
}
