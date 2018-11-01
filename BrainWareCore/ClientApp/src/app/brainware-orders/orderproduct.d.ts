
declare namespace Sales {
  interface OrderProduct {
    orderId: number;
    productId: number;
    product: Product;
    quantity: number;
    price: number;
  }
}
