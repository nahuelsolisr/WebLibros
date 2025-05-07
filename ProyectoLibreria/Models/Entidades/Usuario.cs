﻿namespace ProyectoLibreria.Models.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null;
        public string? URLFotoPerfil { get; set; } 
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
