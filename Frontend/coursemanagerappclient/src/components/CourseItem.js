import React from 'react';
import { Button, ListGroup } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const CourseItem = ({ course, onDelete, onEdit }) => {
  return (
    <ListGroup.Item>
      <div className="d-flex justify-content-between align-items-center">
        <div>
          <p><strong>ID:</strong> {course.id}</p>
          <p><strong>Subject:</strong> {course.subject}</p>
          <p><strong>Course Number:</strong> {course.courseNumber}</p>
          <p><strong>Description:</strong> {course.description}</p>
        </div>
        <div>
          <Button variant="primary" className="mr-2" onClick={() => onEdit(course)}>Edit</Button>
          <Button variant="danger" onClick={() => onDelete(course.id)}>Delete</Button>
        </div>
      </div>
    </ListGroup.Item>
  );
};

export default CourseItem;