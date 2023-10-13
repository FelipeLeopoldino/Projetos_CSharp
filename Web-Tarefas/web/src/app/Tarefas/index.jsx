"use client";
import { useEffect, useState } from "react";
import { Tabela, Apagar, Editar } from "./Tarefas.styles";
import api from "../services/api";

export default function Tarefas() {
  const [dados, setDados] = useState([]);

  useEffect(() => {
    async function getAll() {
      try {
        const response = await api.get("/Tarefas");
        setDados(response.data);
      } catch (error) {
        console.log(error);
      }
    }

    getAll();
  }, []);

  async function handleDelete(id) {
    try {
      await api.delete(`/Tarefas/${id}`);
      const updatedDados = dados.filter((item) => item.id !== id);
      setDados(updatedDados);
    } catch (error) {
      console.log(error);
    }
  }

  function formatarData(data) {
    const dataObj = new Date(data);
    const dia = String(dataObj.getDate()).padStart(2, "0");
    const mes = String(dataObj.getMonth() + 1).padStart(2, "0");
    const ano = dataObj.getFullYear();
    return `${dia}/${mes}/${ano}`;
  }

  return (
    <>
      <Tabela>
        <thead>
          <tr>
            <th>Titulo</th>
            <th>Descrição</th>
            <th>Data</th>
            <th></th>
            <th></th>
          </tr>
        </thead>

        {dados.map((item) => (
          <tbody key={item.id}>
            <tr>
              <td>{item.nome}</td>
              <td>{item.descricao}</td>
              <td>{formatarData(item.dataDeConclusao)}</td>
              <td>
                <Editar>Editar</Editar>
                <Apagar onClick={() => handleDelete(item.id)}>Apagar</Apagar>
              </td>
            </tr>
          </tbody>
        ))}
      </Tabela>
    </>
  );
}
