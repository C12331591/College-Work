SELECT stock_code, stock_profit_TD (stock_code) FROM stock;
SELECT customer_id, customer_name, to_char ( customer_spent(customer_id), 'U999,999.99') FROM customer;
SELECT staff_no, staff_name, total_emp_sales(staff_no) FROM staff;
