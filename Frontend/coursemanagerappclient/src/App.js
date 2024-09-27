import React, { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import CourseList from './components/CourseList';
import AddCourse from './components/AddCourse';
import SearchCourse from './components/SearchCourse';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css'; // 
const App = () => {
  const [courses, setCourses] = useState([]);

  const handleAddCourse = (newCourse) => {
    setCourses([...courses, newCourse]);
  };

  return (
    <div className="container-fluid">
      <Header />
      <div className="row">
        <Sidebar className="col-md-3" />
        <div className="col-md-9">
          <Routes>
            <Route path="/courses/list" element={<CourseList courses={courses} />} />
            <Route path="/courses/add" element={<AddCourse onAdd={handleAddCourse} />} />
            <Route path="/courses/search" element={<SearchCourse />} />
            <Route path="/students" element={<h2>Students Page</h2>} />
          </Routes>
        </div>
      </div>
    </div>
  );
};

export default App;