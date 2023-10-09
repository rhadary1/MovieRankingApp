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
            <div className="items-not-ranked">
             { 
                    (items != null)
                        ? items.map((item) =>
                            <div>
                                <img className="unranked-cell"  id={`item-${item.id}`} src={MovieImageArray.find(o => o.id === item.imageId)?.image}></img>
                                <div className="unranked-cell-text">{item.title}</div>
                             </div>)
                    : <div>Loading...</div>          
             }
             </div>
        </main>
    )
}