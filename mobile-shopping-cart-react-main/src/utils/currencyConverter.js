export const currency = function (number) {
  // return new Intl.NumberFormat('en-IN', {
  //   style: 'currency',
  //   currency: 'INR',
  //   minimumFractionDigits: 2,
  // }).format(number);

  // * OR

  return new Intl.NumberFormat('en-IN').format(number);
};
