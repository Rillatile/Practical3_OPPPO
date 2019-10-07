module Practical3.Films

type IGeneral =
    abstract getRating: float32 with get
    abstract Print: string with get

type FeatureFilm =
    {
        m_title: string
        m_producer: string
        m_rating: float32
    }

    override this.ToString() =
        "Title: " + this.m_title + ", producer: " + this.m_producer + ", rating: " + this.m_rating.ToString()

type CartoonType =
    | Drawn
    | Dollish
    | Plasticine

type CartoonFilm =
    {
        m_title: string
        m_type: CartoonType
        m_rating: float32
    }

    override this.ToString() =
        "Title: " + this.m_title + ", type: " + this.m_type.ToString() + ", rating: " + this.m_rating.ToString()

type HorrorFilm =
    {
        m_title: string
        m_producer: string
        m_rating: float32
    }

    override this.ToString() =
        "Title: " + this.m_title + ", producer: " + this.m_producer + ", rating: " + this.m_rating.ToString()

type Film =
    | Feature of FeatureFilm
    | Cartoon of CartoonFilm
    | Horror of HorrorFilm
    | Incorrect

    interface IGeneral with
        override this.getRating =
            match this with 
                | Feature f -> f.m_rating
                | Cartoon c -> c.m_rating
                | Horror h -> h.m_rating
        override this.Print =
            match this with
                | Feature f -> f.ToString()
                | Cartoon c -> c.ToString()
                | Horror h -> h.ToString()
