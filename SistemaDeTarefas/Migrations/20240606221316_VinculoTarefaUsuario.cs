﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class VinculoTarefaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Tarefa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Usuarios_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_UsuarioId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Tarefa");
        }
    }
}
