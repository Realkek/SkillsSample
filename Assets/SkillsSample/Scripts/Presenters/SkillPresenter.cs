using System.Collections;
using System.Collections.Generic;
using SkillsSample.Scripts.Models;
using SkillsSample.Scripts.Views;
using UnityEngine;

public class SkillPresenter
{
    private SkillModel model;
    private SkillView view;

    public SkillPresenter(SkillModel model, SkillView view)
    {
        this.model = model;
        this.view = view;

        // Подписываемся на события кнопок и обрабатываем их
        view.LearnButtonClicked += OnLearnButtonClicked;
        view.ForgetButtonClicked += OnForgetButtonClicked;
    }

    private void OnLearnButtonClicked()
    {
        /*if (model.CanBeLearned())
        {
            model.LearnSkill();
            view.UpdateSkillUI();
        }*/
    }

    private void OnForgetButtonClicked()
    {
        model.ForgetSkill();
       // view.UpdateSkillUI();
    }
}