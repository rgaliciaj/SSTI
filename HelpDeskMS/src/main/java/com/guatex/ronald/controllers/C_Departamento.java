package com.guatex.ronald.controllers;

import java.util.LinkedList;
import java.util.List;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.guatex.ronald.dao.D_Departamento;
import com.guatex.ronald.models.E_Departamento;

@RestController
public class C_Departamento {
	
	@GetMapping ("/obtenerDepartamentos")
	public @ResponseBody List<E_Departamento> obtenerDepartamentos(){
		List<E_Departamento> listDeptos = new D_Departamento().listDepto();
		return listDeptos;
	}
	
	@PostMapping("/crearDepartamento")
	public List<E_Departamento> crearDepartamento(@RequestBody E_Departamento depto) {
		System.out.println("Ingresa al método");
		List<E_Departamento> respuesta = new LinkedList<>();
		new D_Departamento().insertarDepto(depto);
		
		for (E_Departamento e : respuesta) {
			System.out.println("id depto:     " + e.getIdDepartamento());
			System.out.println("nombre depto: " + e.getNombreDepartamento());
			System.out.println("id depto padre: " + e.getIdDeptoPadre());
		}
		
		return respuesta;
	}

}
