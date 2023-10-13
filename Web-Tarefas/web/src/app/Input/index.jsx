"use client";
import { useState } from "react";
import {
  Button,
  Container,
  Form,
  SubTitle,
  Title,
  TitleTarefa,
  SubTitleTarefa,
  InputTarefa,
  InputDescricao,
} from "./InputTarefas.styles";
import api from "../services/api";

export default function InputTarefas() {
  const [nomeTarefa, setNomeTarefa] = useState("");
  const [descricaoTarefa, setDescricaoTarefa] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const dadosParaEnviar = {
        nome: nomeTarefa,
        descricao: descricaoTarefa,
      };

      await api.post("Tarefas", dadosParaEnviar, {
        headers: {
          "Content-Type": "application/json",
        },
      });

      setNomeTarefa("");
      setDescricaoTarefa("");
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <Container>
      <Form onSubmit={handleSubmit}>
        <TitleTarefa>
          <Title>Tarefa</Title>
          <label htmlFor="nomeTarefa"></label>
          <InputTarefa
            type="text"
            id="nomeTarefa"
            placeholder="Nome da Tarefa, no max 40 caracters"
            value={nomeTarefa}
            onChange={(e) => setNomeTarefa(e.target.value)}
            required
            maxLength={40}
          />
        </TitleTarefa>

        <SubTitleTarefa>
          <SubTitle>Descrição</SubTitle>
          <label htmlFor="descricaoTerefa"></label>
          <InputDescricao
            type="text"
            id="descricaoTarefa"
            placeholder="Descrição da terefa, no max 60 caracters"
            value={descricaoTarefa}
            onChange={(e) => setDescricaoTarefa(e.target.value)}
            maxLength={60}
          />
        </SubTitleTarefa>

        <Button type="submit">Enviar</Button>
      </Form>
    </Container>
  );
}
