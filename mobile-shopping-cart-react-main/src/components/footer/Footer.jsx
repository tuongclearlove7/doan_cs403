import React from 'react';
import PropTypes from 'prop-types';
import footer_styles from './Footer.module.css'

const Footer = props => {
    return (
        <div className={footer_styles.footer_container}>
            <hr/>
            <br/>
            <br/>
            <h5>@NHOM3-MOBILE-SHOP</h5>
            <br/>
            <br/>
            <br/>
        </div>
    );
};

Footer.propTypes = {
    
};

export default Footer;