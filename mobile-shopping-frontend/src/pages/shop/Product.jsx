import React, { useContext } from 'react';
import { ShopContext } from '../../context/shopContext';
import { currency } from '../../utils/currencyConverter';
import {Link} from "react-router-dom";

const Product = (props) => {
  const { id, productName, price, productImage } = props.data;

  const money = currency(price);

  const { addToCart, cartItems } = useContext(ShopContext);

  const cartItemCount = cartItems[id];
  return (
    <div className="product">
        <Link to={`/detail/${id}`}>
            <img src={productImage} alt={productName}/>
        </Link>
        <div className="description">
        <p>
          <strong>Xem chi tiết: {' '}
              <Link to={`/detail/${id}`}>{productName}</Link>
          </strong>
        </p>
        <h4>GIÁ: ₹{money}</h4>
      </div>
      <button className="addToCartBtn" onClick={() => addToCart(id)}>
        THÊM VÀO GIỎ HÀNG
        <span className="itemSize">
          {cartItemCount > 0 && <>{cartItemCount}</>}
        </span>
      </button>
    </div>
  );
};

export default Product;
