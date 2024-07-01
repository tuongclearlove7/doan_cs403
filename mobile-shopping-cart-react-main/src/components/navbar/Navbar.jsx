import React from 'react';
import { Link } from 'react-router-dom';
import { ShoppingCart } from 'phosphor-react';

import './Navbar.css';

const Navbar = () => {
  return (
    <nav className="navbar">
      <Link to="/" className="links">
        NHOM3-MOBILE-SHOP
      </Link>
      <Link to="/cart" className="links">
          <span className={"underline"}>XEM GIỎ HÀNG </span>
          <ShoppingCart size={32} className="cartIcon" />
      </Link>
    </nav>
  );
};

export default Navbar;
