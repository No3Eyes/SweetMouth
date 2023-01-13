﻿var webApiBaseUri = "https://localhost:7096/";
var appVue = new Vue({
    el: "#appVue",
    name: "appVue",
    data: {
        articlePostNum: null,
        Title: null,
        SubTitle: null,
        article: null,
    },
    mounted() {
        _this = this;
        _this.LogAricleID();
    },
    methods: {
        LogAricleID: function () {
            let _this = this;
            axios.get(`${webApiBaseUrl}api/Blogs`).then(res => {
                //_this.articlePostNum = res.data;
                for (let i = 0; i < res.data.length; i++) {
                    _this.articlePostNum = res.data[i].articleID;
                }
            });

        },
        PostNewBlog: function () {
            let _this = this;
            let request = {};
            let Time = new Date();

            request.articleID = _this.articlePostNum += 1;
            //console.log(_this.articlePostNum)
            request.memberID = 10007;
            request.floor = 0;
            request.time = Time;
            request.title = _this.Title;
            request.SubTitle = _this.SubTitle;
            request.Article = _this.article;
            axios.post(`${webApiBaseUri}api/Blogs`, request).then(res => {
                alert("發文成功")
                window.location = "/Home/Blog"
            })
        },
    },
})
