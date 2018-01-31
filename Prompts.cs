using System;
using System.Windows.Forms;

namespace Leaf.Forms
{
    public static class Prompts
    {
        /// <summary>
        /// Запрашивает подтвержение от пользователя на принудительный выход из программы, с возможной потерей результатов.
        /// Сообщение предлагает изначально нажать "Нет", а после нажать кнопку "Остановить", чтобы результаты работы были сохранены.
        /// </summary>
        /// <returns>
        /// Вернет истину если пользователь согласился на принудительный выход из программы и резкую остановку работы, без сохранения результатов.
        /// </returns>
        public static bool ExitWorkCancel()
        {
            var result = MessageBox.Show(
                "ВНИМАНИЕ: Возможна потеря результатов работы!" + Environment.NewLine +
                "Задачи еще выполняются, прервать их принудительно?" + Environment.NewLine + Environment.NewLine +
                "Рекомендуется ответить \"Нет\", затем нажать красную кнопку \"Стоп\" для плавного завершения и сохранения результатов работ.",
                "Принудительная остановка работы", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            return result == DialogResult.Yes;
        }
    }
}
