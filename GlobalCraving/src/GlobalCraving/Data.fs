module Data
module DummyData =
    open Models

    let burgerMenu =
        let burger1 = {
            name = "Big Whack"
            bread = "White Bread"
            meatType = "Carnivore"
            meatSize = 150
            extras = ["Cheese"]
        }
        [burger1]