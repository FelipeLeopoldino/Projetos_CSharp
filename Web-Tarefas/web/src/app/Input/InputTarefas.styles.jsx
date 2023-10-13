import styled from "styled-components";

export const Container = styled.div`
  display: flex;
  text-align: center;
  justify-content: center;
  align-items: center;
  gap: 2rem;
  margin-top: 1.5rem;
`;

export const Form = styled.form`
  display: flex;

  align-items: center;
  text-align: center;
  justify-content: center;
  flex-direction: column;
  gap: 10px;
`;

export const TitleTarefa = styled.div`
  display: flex;
  gap: 10px;
`;

export const Title = styled.h2`
  width: 10rem;
  color: white;
  font-size: 2rem;
`;

export const InputTarefa = styled.input`
  width: 20rem;
  border-radius: 5px;
  border: none;
  padding-left: 5px;

  color: #007bff;
  font-weight: 600;
`;

export const SubTitleTarefa = styled.div`
  display: flex;
  gap: 10px;
`;

export const InputDescricao = styled.input`
  width: 30rem;
  border-radius: 5px;
  border: none;
  padding-left: 5px;

  color: #0654a7;
  font-weight: 600;
`;

export const SubTitle = styled.h2`
  width: 10rem;
  color: gray;
  font-size: 2rem;
`;

export const Button = styled.button`
  margin-top: 1rem;
  padding: 0.5rem;
  width: 10rem;

  font-size: 1.5rem;
  border-radius: 5px;

  border: none;
  background: #0101b3;
  color: white;

  cursor: pointer;

  transition: 0.2s;

  &:hover {
    background: #0101b390;
  }
`;
