import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import Header from './components/Header';
import Footer from './components/Footer';
import './App.css';

const App = () => {
    return (
        <Router>
            <div className="App">
                <Header />
                <Routes>
                    <Route exact path="/" element={<HomePage />} />
                    {/* Adauga alte rute aici */}
                </Routes>
                <Footer />
            </div>
        </Router>
    );
};

export default App;
