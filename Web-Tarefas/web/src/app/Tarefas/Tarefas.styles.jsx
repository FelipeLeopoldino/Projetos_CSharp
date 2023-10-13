import styled from "styled-components";

export const Tabela = styled.table`
  display: flex;
  justify-content: space-around;
  align-items: center;
  text-align: center;
  flex-direction: column;

  margin-top: 1rem;

  thead {
    background: #000050;
    width: 70vw;
    border-radius: 5px;
    padding: 20px;
    color: #ceace6;
    font-size: 1.5rem;

    tr {
      display: flex;
      justify-content: space-between;
    }
  }

  tbody {
    background: #0b0bf353;
    width: 70vw;
    border-radius: 5px;
    padding: 20px;
    color: #c786f3;
    font-size: 1.5rem;
    margin-top: 5px;

    tr {
      display: flex;
      justify-content: space-between;
    }

    td:last-child {
      display: flex;
      gap: 10px;
    }
  }
`;

export const Editar = styled.button`
  padding: 10px;
  border: none;
  border-radius: 5px;
  background: #ffc107;
  color: white;
  font-weight: 600;
  width: 5rem;
  cursor: pointer;
  transition: 0.2s;

  &:hover {
    background: #ffc107b2;
  }
`;

export const Apagar = styled.button`
  padding: 10px;
  border: none;
  border-radius: 5px;
  background: #dc3545;
  color: white;
  font-weight: 600;
  width: 5rem;
  cursor: pointer;
  transition: 0.2s;

  &:hover {
    background: #dc3546a2;
  }
`;
