import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom'; 
import CourseItem from './CourseItem';
import EditCourseForm from './EditCourseForm';
import 'bootstrap/dist/css/bootstrap.min.css';

const CourseList = () => {
  const [courses, setCourses] = useState([]);
  const [editingCourse, setEditingCourse] = useState(null);
  const navigate = useNavigate(); 
  useEffect(() => {
    fetchCourses();
  }, []);

  const fetchCourses = async () => {
    try {
      const response = await fetch('http://localhost:5091/api/Course');
      const data = await response.json();
      setCourses(data);
    } catch (error) {
      console.error('Error fetching courses:', error);
    }
  };

  const deleteCourse = async (id) => {
    try {
      const response = await fetch(`http://localhost:5091/api/Course/${id}`, {
        method: 'DELETE',
      });
  
      if (response.status === 204) { 
        setCourses(courses.filter(course => course.id !== id));
      } else {
        console.error('Error deleting course:', response.statusText);
      }
    } catch (error) {
      console.error('Error deleting course:', error);
    }
  };

  const editCourse = (course) => {
    setEditingCourse(course);
  };

  const updateCourse = async (updatedCourse) => {
    try {
      const response = await fetch(`http://localhost:5091/api/Course/${updatedCourse.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedCourse),
      });
  
      if (response.status === 204) { 
        setCourses(courses.map(course => (course.id === updatedCourse.id ? updatedCourse : course)));
        setEditingCourse(null);
        navigate('/courses/list'); 
      } else {
        console.error('Error updating course:', response.statusText);
      }
    } catch (error) {
      console.error('Error updating course:', error);
    }
  };

  const handleCancelEdit = () => {
    setEditingCourse(null);
    navigate('/courses/list'); 
  };

  return (
    <div>
      <h2>Course List</h2>
      {editingCourse ? (
        <EditCourseForm course={editingCourse} onSave={updateCourse} onCancel={handleCancelEdit} />
      ) : (
        <ul className="list-group">
          {courses.map(course => (
            <CourseItem key={course.id} course={course} onDelete={deleteCourse} onEdit={editCourse} />
          ))}
        </ul>
      )}
    </div>
  );
};

export default CourseList;