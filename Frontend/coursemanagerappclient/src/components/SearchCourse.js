import React, { useState } from 'react';
import { Form, Button, Alert, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const SearchCourse = () => {
  const [courseId, setCourseId] = useState('');
  const [searchResult, setSearchResult] = useState(null);
  const [error, setError] = useState('');

  const handleSearch = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`http://localhost:5091/api/Course/${courseId}`);
      if (!response.ok) {
        throw new Error('Course not found');
      }
      const data = await response.json();
      setSearchResult(data);
      setError('');
    } catch (error) {
      setError(error.message);
      setSearchResult(null);
    }
  };

  return (
    <Container className="mt-5">
      <h2>Search Course</h2>
      {error && <Alert variant="danger">{error}</Alert>}
      <Form onSubmit={handleSearch} className="p-3 border rounded">
        <Form.Group controlId="courseId" className="mb-3">
          <Form.Label>Course ID:</Form.Label>
          <Form.Control
            type="text"
            value={courseId}
            onChange={(e) => setCourseId(e.target.value)}
          />
        </Form.Group>
        <Button type="submit" variant="primary">Search</Button>
      </Form>
      {searchResult && (
        <Form className="p-3 border rounded mt-4">
          <h3>Search Result:</h3>
          <Form.Group controlId="id" className="mb-3">
            <Form.Label>ID:</Form.Label>
            <Form.Control type="text" value={searchResult.id} readOnly />
          </Form.Group>
          <Form.Group controlId="subject" className="mb-3">
            <Form.Label>Subject:</Form.Label>
            <Form.Control type="text" value={searchResult.subject} readOnly />
          </Form.Group>
          <Form.Group controlId="courseNumber" className="mb-3">
            <Form.Label>Course Number:</Form.Label>
            <Form.Control type="text" value={searchResult.courseNumber} readOnly />
          </Form.Group>
          <Form.Group controlId="description" className="mb-3">
            <Form.Label>Description:</Form.Label>
            <Form.Control type="text" value={searchResult.description} readOnly />
          </Form.Group>
        </Form>
      )}
    </Container>
  );
};

export default SearchCourse;