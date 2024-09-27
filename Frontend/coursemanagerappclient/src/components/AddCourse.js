import React, { useState } from 'react';
import { Form, Button, Alert, Container } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom'; // Importar useNavigate
import 'bootstrap/dist/css/bootstrap.min.css';

const AddCourse = ({ onAdd }) => {
  const [subject, setSubject] = useState('');
  const [courseNumber, setCourseNumber] = useState('');
  const [description, setDescription] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate(); // Inicializar useNavigate

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!/^\d{3}$/.test(courseNumber)) {
      setError('Course number must be a three-digit number');
      return;
    }

    const newCourse = { subject, courseNumber, description };
    try {
      const response = await fetch('http://localhost:5091/api/Course', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newCourse),
      });
      const data = await response.json();
      onAdd(data);
      setSubject('');
      setCourseNumber('');
      setDescription('');
      setError('');
      navigate('/courses/list'); // Redirigir a la lista de cursos
    } catch (error) {
      console.error('Error adding course:', error);
    }
  };

  return (
    <Container className="mt-5">
      <h2>Add Course</h2>
      {error && <Alert variant="danger">{error}</Alert>}
      <Form onSubmit={handleSubmit} className="p-3 border rounded">
        <Form.Group controlId="subject" className="mb-3">
          <Form.Label>Subject:</Form.Label>
          <Form.Control
            type="text"
            value={subject}
            onChange={(e) => setSubject(e.target.value)}
          />
        </Form.Group>
        <Form.Group controlId="courseNumber" className="mb-3">
          <Form.Label>Course Number:</Form.Label>
          <Form.Control
            type="text"
            value={courseNumber}
            onChange={(e) => setCourseNumber(e.target.value)}
          />
        </Form.Group>
        <Form.Group controlId="description" className="mb-3">
          <Form.Label>Description:</Form.Label>
          <Form.Control
            type="text"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </Form.Group>
        <Button type="submit" variant="primary">Add Course</Button>
      </Form>
    </Container>
  );
};

export default AddCourse;