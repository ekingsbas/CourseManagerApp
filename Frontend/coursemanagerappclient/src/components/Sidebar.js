import React from 'react';
import { Link } from 'react-router-dom';
import { Nav, Accordion, Card, useAccordionButton } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Sidebar.css'; // Archivo CSS para estilos personalizados

const CustomToggle = ({ children, eventKey }) => {
  const decoratedOnClick = useAccordionButton(eventKey);

  return (
    <Card.Header onClick={decoratedOnClick} style={{ cursor: 'pointer' }}>
      {children}
    </Card.Header>
  );
};

const Sidebar = () => {
  return (
    <Nav className="col-md-3 d-none d-md-block bg-light sidebar">
      <div className="sidebar-sticky">
        <Accordion>
          <Card>
            <CustomToggle eventKey="0">Courses</CustomToggle>
            <Accordion.Collapse eventKey="0">
              <Card.Body>
                <Nav className="flex-column">
                  <Nav.Link as={Link} to="/courses/list">List Courses</Nav.Link>
                  <Nav.Link as={Link} to="/courses/add">Add Course</Nav.Link>
                  <Nav.Link as={Link} to="/courses/search">Search Courses</Nav.Link>
                </Nav>
              </Card.Body>
            </Accordion.Collapse>
          </Card>
          <Card>
            <Card.Header>
              <Nav.Link as={Link} to="/students">Students</Nav.Link>
            </Card.Header>
          </Card>
        </Accordion>
      </div>
    </Nav>
  );
};

export default Sidebar;