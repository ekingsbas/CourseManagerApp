import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router } from 'react-router-dom';
import App from './App';
import './index.css'; // Tu archivo CSS personalizado

ReactDOM.render(
  <Router>
    <App />
  </Router>,
  document.getElementById('root')
);