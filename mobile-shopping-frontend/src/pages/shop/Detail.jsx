import React, {useContext, useEffect} from 'react';
import PropTypes from 'prop-types';
import {NavLink, useNavigate, useParams} from "react-router-dom";
import {ShopContext} from "../../context/ShopContext.jsx";
import detail_styles from './detail.module.css'
const Detail = props => {

    const { id } = useParams();
    const { products, addToCart, cartItems } = useContext(ShopContext);
    const product = products.find(item => item.id === Number(id));
    const navigate = useNavigate();

    const cartItemCount = cartItems[id];

    if (!product) {
        return <div>Product not found</div>;
    }

    const navigateHome = () => {
        console.log("/home")
        navigate("/");
    }

    return (
        <div className={detail_styles.container_detail}>
            <div className={detail_styles.margin_left_100px}>
                <div className={detail_styles.margin_bottom_25px}>
                    <span onClick={navigateHome} className={detail_styles.fontsize30px}>
                        TRANG CHỦ/ {' '}
                    </span>
                    <span className={detail_styles.fontsize30px}>
                        CHI TIẾT SẢN PHẨM
                    </span>
                </div>
                <div className={detail_styles.margin_bottom_15px}>
                    <h4>{product.productName}</h4>
                </div>
                <div className={detail_styles.margin_bottom_15px}>
                    <img width={"20%"} src={product.productImage} alt={product.productName}/>
                </div>
                <div className={detail_styles.margin_bottom_15px}>
                    <h4 className={detail_styles.margin_bottom_15px}>GIÁ: ₹{product.price}</h4>
                    <p className={detail_styles.width40}>
                        <span className={detail_styles.fontsize15px}>MÔ TẢ:</span>
                        <span>{` ${product.description}`}</span>
                    </p>
                </div>
                <button className="addToCartBtn" onClick={() => addToCart(id)}>
                    THÊM VÀO GIỎ HÀNG
                    <span className="itemSize">
                      {cartItemCount > 0 && <>{cartItemCount}</>}
                    </span>
                </button>
            </div>
        </div>

    );
};

Detail.propTypes = {};

export default Detail;