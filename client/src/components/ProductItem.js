import React from 'react';
import './ProductItem.css';

const ProductItem = ({ product }) => {
    return (
        <li className="product-item">
            <h3>{product.name}</h3>
            <p>{product.description}</p>
            <p>Price: ${product.price}</p>
        </li>
    );
};

export default ProductItem;
