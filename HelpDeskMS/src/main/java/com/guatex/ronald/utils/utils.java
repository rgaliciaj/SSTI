package com.guatex.ronald.utils;

public class utils {
	public String quitaNulo(String var) {
		String respuesta = var ==null || var.isEmpty() ? var = "" : var.trim();
		return respuesta;
	}
}
