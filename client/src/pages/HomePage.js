import React from 'react';
import Banner from '../components/Banner';
import ProductList from '../components/ProductList';
import './HomePage.css';

const HomePage = () => {
    return (
        <div className="home-page">
            <Banner />
            <ProductList />
        </div>
    );
};

export default HomePage;
