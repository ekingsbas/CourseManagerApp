import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom'; // Importar useNavigate
import 'bootstrap/dist/css/bootstrap.min.css';

const EditCourseForm = ({ course, onSave, onCancel }) => {
  const [subject, setSubject] = useState(course.subject);
  const [courseNumber, setCourseNumber] = useState(course.courseNumber);
  const [description, setDescription] = useState(course.description);
  const navigate = useNavigate(); // Inicializar useNavigate

  const handleSubmit = (e) => {
    e.preventDefault();
    onSave({ ...course, subject, courseNumber, description });
    navigate('/courses/list'); // Redirigir a la lista de cursos después de guardar
  };

  const handleCancel = () => {
    onCancel();
    navigate('/courses/list'); // Redirigir a la lista de cursos después de cancelar
  };

  return (
    <Form onSubmit={handleSubmit} className="p-3 border rounded">
      <h2 className="mb-3">Edit Course</h2>
      <Form.Group controlId="subject">
        <Form.Label>Subject:</Form.Label>
        <Form.Control
          type="text"
          value={subject}
          onChange={(e) => setSubject(e.target.value)}
        />
      </Form.Group>
      <Form.Group controlId="courseNumber">
        <Form.Label>Course Number:</Form.Label>
        <Form.Control
          type="text"
          value={courseNumber}
          onChange={(e) => setCourseNumber(e.target.value)}
        />
      </Form.Group>
      <Form.Group controlId="description">
        <Form.Label>Description:</Form.Label>
        <Form.Control
          type="text"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
      </Form.Group>
      <div className="d-flex justify-content-between mt-3">
        <Button type="submit" variant="primary">Save</Button>
        <Button type="button" variant="secondary" onClick={handleCancel}>Cancel</Button>
      </div>
    </Form>
  );
};

export default EditCourseForm;