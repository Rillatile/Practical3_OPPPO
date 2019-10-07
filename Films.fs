module Practical3.Films

type IPrintable =
    abstract getType: string with get

type FeatureFilm =
    {
        m_title: string
        m_producer: string
        m_rating: float32
    }

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

type HorrorFilm =
    {
        m_title: string
        m_producer: string
        m_rating: float32
    }

type Film =
    | Feature of FeatureFilm
    | Cartoon of CartoonFilm
    | Horror of HorrorFilm
    | Incorrect

    interface IPrintable with
        override this.getType = this.GetType().Name
