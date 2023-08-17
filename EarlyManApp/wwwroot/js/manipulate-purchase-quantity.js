
document.addEventListener('DOMContentLoaded', () => {
    /* this script allows the user to increase the quantity of a product item */
    let quantity_increase_buttons = document.getElementsByClassName("increase_quantity_btn");
    //let quantity_increase_buttons_nsobu = [1,2,3,4,5]
    Array.from(quantity_increase_buttons).forEach(function (increaseButton) {
        increaseButton.addEventListener("click", () => {
            let currentId = increaseButton.id;
            let textboxId = currentId.split("_")[0];
            let quantityTextbox = document.getElementById(textboxId);
            let currentQuantity = parseInt(quantityTextbox.value);

            if (currentQuantity > 99) { }
            else {
                currentQuantity += 1;
            }
            quantityTextbox.value = currentQuantity;

        });
        
    });



    /* same as above except here we decrease.*/
    let quantity_decrease_buttons = document.getElementsByClassName("decrease_quantity_btn");
    Array.from(quantity_decrease_buttons).forEach(function (decreaseButton) {
        decreaseButton.addEventListener("click", () => {
            let currentId = decreaseButton.id;
            let textboxId = currentId.split("_")[0];
            let quantityTextbox = document.getElementById(textboxId);
            let currentQuantity = parseInt(quantityTextbox.value);

            if (currentQuantity == 0) { }
            else {
                currentQuantity -= 1;
            }
            quantityTextbox.value = currentQuantity;

        });
        
    });
});