package com.guatex.ronald.controllers;

import java.util.LinkedList;
import java.util.List;

import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.objenesis.instantiator.basic.NewInstanceInstantiator;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.guatex.ronald.dao.D_Usuario;
import com.guatex.ronald.models.E_Usuario;
import com.guatex.ronald.models.pkgUsuario;

@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping("usuario")
public class RestUser {
//	https://youtu.be/Mi8RB38lYUo
	@GetMapping("/obtenerUsuario")
	public pkgUsuario getUser(@RequestParam (name = "user") String user, @RequestParam (name = "pass") String pass){
		String usuario = user.toUpperCase();
		
		System.out.println("Hola si logo ingresar: ["+usuario+" == "+ pass +"]");
//		return new ResponseEntity<>(HttpStatus.ACCEPTED);
		
		pkgUsuario usuarioResp= new D_Usuario().getUser(usuario, pass);
		System.out.println("valor resultante: ["+usuarioResp.getCodigo()+" and "+ usuarioResp.getMensaje() +"]");
		return usuarioResp;
	}
	
//	@GetMapping("/obtenerUsuarios")
//	public @ResponseBody List<E_Usuario> getUsers(){
//		List<E_Usuario> listResult = new D_Usuario().getUsers();
//		return listResult;
//	}

	
	@PostMapping("/crearUsuario")
	public boolean crearUsuario (E_Usuario usuario) {
		Boolean respuesta = false;//new D_Usuario();
		return respuesta;
	}
	
	
}
