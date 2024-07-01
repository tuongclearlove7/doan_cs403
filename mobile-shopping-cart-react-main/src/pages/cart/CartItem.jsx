import React, { useContext } from 'react';
import { ShopContext } from '../../context/shopContext';
import { currency } from '../../utils/currencyConverter';

const CartItem = (props) => {
  const { id, productName, price, productImage } = props.data;
  const { cartItems, increaseCart, decreaseCart, updateCartItemCount } =
    useContext(ShopContext);

  const money = currency(price);

  return (
    <div className="cartItem">
      <img src={productImage} alt={productName} className="cartImage" />
      <div className="description">
        <p>
          <strong>{productName}</strong>
        </p>
        <h5>Price: ₹{money}</h5>
        <div className="countHandler">
          <button onClick={() => decreaseCart(id)}> - </button>
          <input
            value={cartItems[id]}
            onChange={(e) => updateCartItemCount(Number(e.target.value), id)}
          />
          <button onClick={() => increaseCart(id)}> + </button>
        </div>
      </div>
    </div>
  );
};

export default CartItem;
