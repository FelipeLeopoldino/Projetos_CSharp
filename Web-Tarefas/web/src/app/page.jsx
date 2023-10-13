import HeaderTarefas from "./Header";
import InputTarefas from "./Input";
import Tarefas from "./Tarefas";
import "./globals.css";

export default function Home() {
  return (
    <>
      <HeaderTarefas />
      <InputTarefas />
      <Tarefas />
    </>
  );
}
