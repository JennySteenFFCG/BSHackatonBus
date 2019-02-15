module Models
[<CLIMutable>]
type BurgerDescription = {
    name: string
    bread: string
    meatType: string
    meatSize: int
    extras: string list
}


