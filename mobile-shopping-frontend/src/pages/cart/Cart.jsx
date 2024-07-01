import React, { useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { PRODUCTS } from '../../products';
import { ShopContext } from '../../context/shopContext';
import CartItem from './CartItem';
import { currency } from '../../utils/currencyConverter';

import './Cart.css';

const Cart = () => {
  const { cartItems, getTotalCartAmount, checkout } = useContext(ShopContext);
  const totalAmount = getTotalCartAmount();

  const money = currency(totalAmount);

  const navigate = useNavigate();

  return (
    <div className="cart">
      <div>
        <h1>GIỎ HÀNG CỦA BẠN</h1>
      </div>
        <br/>
        <div>
            {totalAmount > 0 ? (
                <div className="checkout">
                    <h4>TỔNG TIỀN: ₹{money}</h4>
                    <button onClick={() => navigate('/')}>XEM ĐIỆN THOẠI</button>
                    <button
                        onClick={() => {
                            checkout();
                            navigate('/checkout');
                        }}
                    >
                        ĐẶT HÀNG NGAY
                    </button>
                </div>
            ) : (
                <h1>GIỎ HÀNG CỦA BẠN ĐANG TRỐNG</h1>
            )}
        </div>
      <div className="cart">
        {PRODUCTS.map((product, index) => {
          if (cartItems[product.id] !== 0) {
            return <CartItem data={product} key={index} />;
          }
        })}
      </div>
    </div>
  );
};

export default Cart;
