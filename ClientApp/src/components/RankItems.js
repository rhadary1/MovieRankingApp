import React, { useState, useEffect } from "react"
import MovieImageArray from "./MovieImages.js"
import MovieImageArr from "./MovieImages.js";

export default function RankItems() {
    const [items, setItems] = useState([]); 
    const itemType = "movie"; 

    useEffect(() => {
        fetch(`./item/itemsByType/${itemType}`)
            .then((results) => {
                return results.json();
            })
            .then(data => {
                setItems(data)
            })
    }, [])
    return (
        <main>
            { 
                (items != null)
                    ? items.map((item) =>
                        <div>
                            <h5>{item.title}</h5>
                            <img id={`item-${item.id}`} src={MovieImageArray.find(o => o.id === item.imageId)?.image}></img>
                        </div>)
                : <div>Loading...</div>               
            }
        </main>
    )
}